using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.IO;
public class MyKey {
    public string Name { get; set; }
    public string Id { get; set; }
}
public class MyKeyComparer :IEqualityComparer<MyKey> {
    public bool Equals( MyKey x, MyKey y ) {
        return x.Id.Equals( y.Id ) ;
    }
    public int GetHashCode( MyKey obj ) {
        if( obj == null ) 
            throw new ArgumentNullException();
        return ((MyKey)obj).Id.GetHashCode();
    }
}
public class MyDictionary :Dictionary<MyKey, string> {
    public MyDictionary()
        :base( new MyKeyComparer() )
    {}
}
class Program {
    static void Main( string[] args ) {
        var myDictionary = new MyDictionary();
        myDictionary.Add( new MyKey() { Name = "MyName1", Id = "MyId1" }, "MyData1" );
        myDictionary.Add( new MyKey() { Name = "MyName2", Id = "MyId2" }, "MyData2" );
        var ser = new DataContractSerializer( typeof( MyDictionary ) );
        using( FileStream writer = new FileStream( "Test.Xml", FileMode.Create ) )
            ser.WriteObject( writer, myDictionary );
        using( FileStream reader = new FileStream( "Test.Xml", FileMode.Open ) )
            myDictionary = (MyDictionary)ser.ReadObject( reader );
    }
}
