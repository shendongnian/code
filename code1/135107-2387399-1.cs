    public static void fillCheckList(string ListType,int RecordNum,CheckBox chkRequired, params TextBox[] txtBoxes)
    {
       TextBox txtComplete = null;
       TextBox txtMemo = null;
       TextBox txtThirdOne = null;
       if(txtBoxes.Length < 1)
       {
          throw new Exception("At least the txtComplete-Textbox has to be given");
       }
       else
       {
          txtComplete = txtBoxes[0];
          
          if(txtBoxes.Length >= 2)
              txtMemo = txtBoxes[1];
          
          if(txtBoxes.Length >= 3)
              txtThirdOne = txtBoxes[2];
       }
       // do stuff    
    }
