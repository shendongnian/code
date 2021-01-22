       public class AnyCLass
       {
           public string Message{get; set;}
           // any other methods or properties in class ...
           // note thatin any method which you change the Message content it should be 
           // used and if you do not call the method which change the Message value ,
           // you have a string.Empty value
           // to test this change the Message Value in Constructor like below
           public AnyClass()
           {
              this.Message = "You have to change the value somewhere which call with user";
           }
       }
       public partial class Form1.cs
       {
           AnyClass instance = new AnyClass();
           Label1.Text = instance.Message;
       }
