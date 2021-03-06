    using System.Windows.Forms;
    public IEnumerable<Control> DescendantControls(this Control control)  
    {   
        foreach(var child in control.Controls)  
        {  
            yield return child;
            foreach(var descendant in child.DescendantControls())  
            {
                yield return descendant;
            }
        }
    }
