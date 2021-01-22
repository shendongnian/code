    You can see below a very basic example of `dependency property` that creates a `custom control text box` in which space will be not allowed means user can not type space into text box.
    
    1) Create a class with the name of `ValidatedTextBox` and write the following code in this class file:
    
    public class ValidatedTextBox : TextBox  
    {  
       public ValidatedTextBox()  
       {  
                 
       }
    
       public static readonly DependencyProperty IsSpaceAllowedProperty =  
       DependencyProperty.Register("IsSpaceAllowed", typeof(bool),     typeof(ValidatedTextBox));  
    
       public bool IsSpaceAllowed  
       {  
           get  
           {  
                return (bool)base.GetValue(IsSpaceAllowedProperty);  
           }  
           set  
           {  
                base.SetValue(IsSpaceAllowedProperty, value);  
           }  
       } 
     
       protected override void OnPreviewKeyDown(KeyEventArgs e)  
       {  
             base.OnPreviewKeyDown(e);  
             if (!IsSpaceAllowed && (e.Key == Key.Space))  
             {  
                  e.Handled = true;  
             }  
        }  
     }  
    
    2) Now use the above control into your `.XAML` file as below:
    
      a) Add namespace of custom control text box like below:
    
    xmlns:CustomControls="clr-namespace: ValidatedTextBox;assembly= ValidatedTextBox "  
    
      b) Now, use custom control text box like below:
       
      <CustomControls:ValidatedTextBox IsSpaceAllowed="False"  
     x:Name="MyTextBox" /> 
