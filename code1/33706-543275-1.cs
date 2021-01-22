public enum SerializeObjTestClassEnum {
  one = 1, two, three, four
}
[Serializable]
public class SerializeObjTestClass {
  public string Name { get; set; }
  public int Id { get; set; }
  public SerializeObjTestClassEnum MyEnum { get; set; }
}
public void SerializeObject_Test_Basic_Object() {
  var obj = new SerializeObjTestClass {
    Id = 1, Name = "Test", MyEnum = SerializeObjTestClassEnum.three
  };
  var json = (new JavaScriptSerializer()).Serialize(obj);
}
----------
this code gives you json = '**{"Name":"Test","Id":1,"MyEnum":0}**'
