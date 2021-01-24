        I'm not sure but you can try using this
           1)define driver in global scope
           
        what you are doing is defining and declaring **driver** variable inside the 
         scope of button click.so,it will not be accessible from any other method...
          
         secondly,if you are making a function call within the button click event 
          then use its function parameters.
          Like in watcher_changed method you can try using this
           
    > assuming you are calling watcher_changed function as watcher_changed(driver,"")
    else it will give you error
    
    
    using System;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
        namespace MyStuff
        {
            public class MyClass : Page
            {
                **`define your IwebDriver here`**
    
               public void MyButton_Click(Object sender, EventArgs e)
               {
                   **access IwebDriver here**
               }
    
               private void Watcher_Changed(object sender, FileSystemEventArgs e)
               {
                   sender.navigate().refresh(); // Can not use driver
               }
             
           }
        }
            
           
