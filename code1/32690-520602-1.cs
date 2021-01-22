    namespace CustomControls
    {
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
    }
    <%@ Register TagPrefix="MyControls" Namespace="CustomControls"%>
    <MyControls:CustomCheckBox id="chkBox" runat="server" MyValue="value"></MyControls:CustomTextBox>
