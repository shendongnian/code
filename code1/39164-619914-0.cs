    public interface IText
    {
       string Text { get; }
    }
    
    public interface ISuperDooper
    {
       string WhyAmISuperDooper { get; }
    }
    
    public class Control
    {
       public int ID { get; set; }
    }
    
    public class TextControl : Control, IText
    {
       public string Text { get; set; }
    }
    
    public class AnotherTextControl : Control, IText
    {
       public string Text { get; set; }
    }
    
    public class SuperDooperControl : Control, ISuperDooper
    {
       public string WhyAmISuperDooper { get; set; }
    }
    
    public class TestProgram
    {
       static void Main(string[] args)
       {
          List<Control> controls = new List<Control>
                   {
                       new TextControl
                           {
                               ID = 1, 
                               Text = "I'm a text control"
                           },
                       new AnotherTextControl
                           {
                               ID = 2, 
                               Text = "I'm another text control"
                           },
                       new SuperDooperControl
                           {
                               ID = 3, 
                               WhyAmISuperDooper = "Just Because"
                           }
                   };
    
           DoSomething(controls);
       }
    
       static void DoSomething(List<Control> controls)
       {
          foreach(Control control in controls)
          {
             // write out the ID of the control
             Console.WriteLine("ID: {0}", control.ID);
    
             // if this control is a Text control, get the text value from it.
             if (control is IText)
                Console.WriteLine("Text: {0}", ((IText)control).Text);
    
             // if this control is a SuperDooperControl control, get why
             if (control is ISuperDooper)
                Console.WriteLine("Text: {0}", 
                    ((ISuperDooper)control).WhyAmISuperDooper);
          }
       }
    }
