    public class Frm2{
    
     private void Close(){
        if(myDataHasChanged){
          if(dataChanged != null) { 
            dataChanged.BeginInvoke(); 
          }
          this.Close();
        }
     }
    }
