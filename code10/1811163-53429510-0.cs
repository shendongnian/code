    static void main(int[] args)
    {
        while (true)
        {
            System.Drawing.Point mouse = System.Windows.Forms.Cursor.Position; 
            AutomationElement element = AutomationElement.FromPoint(new System.Windows.Point(mouse.X, mouse.Y));
            if (element == null)
            {
                // no element under mouse
                return;
            }
    
            Console.WriteLine("Element at position " + mouse + " is '" + element.Current.Name + "'");
    
            object pattern;
            if (element.TryGetCurrentPattern(ValuePattern.Pattern, out pattern))
            {
                ValuePattern valuePattern = (ValuePattern)pattern;
    
                Console.WriteLine(" Value=" + valuePattern.Current.Value);
            }
    
            if (element.TryGetCurrentPattern(InvokePattern.Pattern, out pattern))
            {
                InvokePattern invokePattern = (InvokePattern)pattern;
    
                //invokePattern.Invoke();
                Console.WriteLine(" invokePattern=" + invokePattern.ToString());
            }
    
            if (element.TryGetCurrentPattern(TableItemPattern.Pattern, out pattern))
            {
                TableItemPattern tableItemPattern = (TableItemPattern)pattern;
    
                Mouse.MoveTo(new Point(mouse.X, mouse.Y));
                Mouse.Click(MouseButton.Left); // Install Microsoft.TestApi from Nuget
    
                Console.WriteLine(" TableItemPattern=" + tableItemPattern.ToString());
            }  
            Thread.Sleep(1000);
        }
    }
