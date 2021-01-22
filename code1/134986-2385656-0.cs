// ... This is a class object of type Foo...
public bool Serialize(string sPath, System.Runtime.Serialization.SerializationBinder serializationBinder) {
	bool bSuccessful = false;
	if (serializationBinder == null) return false;
	try {
		using (FileStream fStream = new FileStream(sPath, FileMode.Create)) {
			try {
				BinaryFormatter bf = new BinaryFormatter();
				bf.Binder = serializationBinder;
				bf.Serialize(fStream, this._someFoo);
				bSuccessful = true;
			} catch (System.Runtime.Serialization.SerializationException sEx) {
				System.Diagnostics.Debug.WriteLine(sEx.ToString());
				bSuccessful = false;
			}
		}
	} catch (System.IO.IOException ioEx) {
		System.Diagnostics.Debug.WriteLine(string.Format("[Serialize(...)] - IO EXCEPTION> DETAILS ARE {0}", ioEx.ToString()));
		bSuccessful = false;
	}
	return bSuccessful;
}
public bool Deserialize(string sFileName, System.Runtime.Serialization.SerializationBinder serializationBinder) {
	bool bSuccessful = false;
	//
	if (!System.IO.File.Exists(sFileName)) return false;
	if (serializationBinder == null) return false;
	this._foo = new Foo();
	//
	try {
		using (FileStream fStream = new FileStream(sFileName, FileMode.Open)) {
			try {
				BinaryFormatter bf = new BinaryFormatter();
				bf.Binder = serializationBinder;
				this._foo = (Foo)bf.Deserialize(fStream);
				bSuccessful = true;
			} catch (System.Runtime.Serialization.SerializationException sEx) {
				System.Diagnostics.Debug.WriteLine(string.Format("[DeSerialize(...)] - SERIALIZATION EXCEPTION> DETAILS ARE {0}", sEx.ToString()));
				bSuccessful = false;
			}
		}
	} catch (System.IO.IOException ioEx) {
		System.Diagnostics.Debug.WriteLine(string.Format("[DeSerialize(...)] - IO EXCEPTION> DETAILS ARE {0}", ioEx.ToString()));
		bSuccessful = false;
	}
	return (bSuccessful == true);
}
// End class method for object class type Foo
public class BarBinder : System.Runtime.Serialization.SerializationBinder {
	public override Type BindToType(string assemblyName, string typeName) {
		Type typeToDeserialize = null;
		try {
			// For each assemblyName/typeName that you want to deserialize to
			// a different type, set typeToDeserialize to the desired type.
			string assemVer1 = System.Reflection.Assembly.GetExecutingAssembly().FullName;
			if (assemblyName.StartsWith("Foo")) {
				assemblyName = assemVer1;
				typeName = "FooBar" + typeName.Substring(typeName.LastIndexOf("."), (typeName.Length - typeName.LastIndexOf(".")));
			}
			typeToDeserialize = Type.GetType(String.Format("{0}, {1}", typeName, assemblyName));
		} catch (System.Exception ex1) {
			throw ex1;
		} finally {
		}
		return typeToDeserialize;
	}
}
