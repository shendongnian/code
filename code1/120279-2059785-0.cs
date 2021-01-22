    public class MyTextBox : System.Windows.Forms.TextBox {
    
    public string MetaMessage {get;set;}
    
    public event SomeCoolEventHandler CoolEvent;
    public delegate SomeCoolEventHandler(object sender, CoolEventArgs args);
    }
    
    public class CoolEventArgs: EventArgs{
    
    ....
    }
