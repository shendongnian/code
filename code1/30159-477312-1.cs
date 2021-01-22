    public class MouseDevice {
        public delegate void ButtonClickedHandler<O, E>(O sender, E e);
    }
    
    public interface IClickable<O,E> {
        event MouseDevice.ButtonClickedHandler<O,E> Clicked;
    }
    
    public class ClickableClass : IClickable<Control,MouseEventArgs>
    {
    
        public event MouseDevice.ButtonClickedHandler<Control, MouseEventArgs> Clicked;
    
        protected void OnButtonClicked(Control sender,MouseEventArgs e) { 
            if (Clicked != null){
                Clicked(sender, e);
            }
        }
    }
    
    public class Test {
        public static void main(string[] args)
        {
            ClickableClass m = new ClickableClass();
            m.Clicked += new MouseDevice.ButtonClickedHandler<Control, MouseEventArgs>(m_Clicked);
        }
    
        static void m_Clicked(Control sender, MouseEventArgs e)
        {
            //Handle Click Event...
        }
    }
