    namespace Datalayer {
    public class dataObject
    {// all the class here } }  
    
    // in it's own dll: Datalayer.Interfaces.dll
    namespace Datalayer.Interfaces{
    public interface IdataObject
    { // interface declaration }
    namespace BusinessLayer {
    public class busObject : IdataObject {
      busObject(){}  
      busObject(int objectID) {//go get the dataObject with the ID}
    }}
