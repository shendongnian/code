    class Control { public string Name; public Control Parent; }
    class Control2 : Control { public string Prop2; }
    
    static class Program
    {
        public static Control GetParentOfType(this Control childControl,
                                              Type parentType)
        {
            Control parent = childControl.Parent;
            while(parent.GetType() != parentType) // throws NullReferenceException when "No control of expected type was found" (due to "parent" being null)
            {
                parent = parent.Parent;
            }
            if(parent.GetType() == parentType)
                return parent;
    
            throw new Exception("No control of expected type was found"); // this line is dead code as null reference throws before this
        }
        public static IEnumerable<Control> GetAncestors(this Control control)
        {
            if (control == null)
                yield break;
            while ((control = control.Parent) != null)
                yield return control;
        }
        
        static void Main()
        {
            var a = new Control { Name = "A" };
            var b = new Control2 { Name = "B", Parent = a, Prop2 = "B is OK!" };
            var c = new Control { Name = "C", Parent = b };
            var d = new Control { Name = "D",  Parent = c };
    
            // teebot's 
            var found = d.GetParentOfType(typeof(Control2));
            ((Control2)found).Prop2.Dump(); // properly returns "B is OK!", but needs 2 lines to be clear, and casting to the same type already defined in the line above
            try { b.GetParentOfType(typeof(Control2));
            } catch (Exception e) { e.GetType().Name.Dump(); } // NullReferenceException
    
            // mine
            d.GetAncestors().OfType<Control2>().First().Prop2.Dump(); // properly returns "B is OK!" (while "yield" and "First()" avoids wasting time looping unneeded ancestors, e.g. "A")
            b.GetAncestors().OfType<Control2>().FirstOrDefault().Dump(); // doesn't throw, just returns null
            d.GetAncestors().Take(2).Select(x => x.Name).ToList().Dump(); // returns a filtered list (instead of a single element) without changing GetAncestors nor wasting performance
        }
    }
