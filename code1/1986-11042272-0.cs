	// compile as:
	// csc file.cs /r:UIAutomationClient.dll /r:UIAutomationTypes.dll /r:WindowsBase.dll
	using System.Windows.Automation;
	using System.Windows.Forms;
	using System;
	
	class Test
	{
	    public static void Main()
	    {
	        // Get element under pointer. You can also get an AutomationElement from a
                // HWND handle, or by navigating the UI tree.
	        System.Drawing.Point pt = Cursor.Position;
	        AutomationElement el = AutomationElement.FromPoint(new System.Windows.Point(pt.X, pt.Y));
	        // Prints its name - often the context, but would be corresponding label text for editable controls. Can also get the type of control, location, and other properties.
	        Console.WriteLine( el.Current.Name );
	    }
	}
