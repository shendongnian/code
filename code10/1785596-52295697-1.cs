    public class NewDataObj{
    .....
     public NewDataObj(DataRow item, string newID, ref int currow){ //second changes
      ....
      ID = string.Format("{{ABC_TEST_{0:000}}}", currow);
      AddtoFile_A();
      
      currow++; //next changes
      ID = string.Format("{{DCI_XRE_{0:000}}}", currow); //new id
      AddtoFile_A2();
     }
