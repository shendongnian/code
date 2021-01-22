    // in it's own dll: Datalayer.Interfaces.dll
    namespace Datalayer.Interfaces{
    public interface IdataObject
    { // interface declaration }
    namespace Datalayer {
    public class dataObject: IdataObject
    {// all the class here } }  
    namespace BusinessLayer {
    public class busObject : IdataObject {
      busObject(){} 
      busObject(IdataObject dataObject) {} 
      busObject(int objectID) {//go get the dataObject with the ID}
    }}
