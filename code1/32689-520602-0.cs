    public class CustomCheckBox : CheckBox
    {
       string _myValue;
       public string MyValue
       {
           get { return _myValue; }
           set { _myValue = value; }
       }
    
       public CustomCheckBox()
       {
       }
    }
    <MyControls:CustomCheckBox ID="chkBox" runat="server" MyValue="value"></MyControls:CustomTextBox>
