    public class SerializeStatic
	{
		public static bool Save(Type static_class, string filename)
		{
			try
			{
				FieldInfo[] fields = static_class.GetFields(BindingFlags.Static | BindingFlags.Public);
				
				object[,] a = new object[fields.Length-1,2]; //one field can´t be serialized, so shouldn´t be counted
				int i = 0;
				foreach (FieldInfo field in fields)
				{
					if(field.Name == "db") continue; // db cant be serialized! so get away.. not very pretty but does its job :)
					a[i, 0] = field.Name;
					a[i, 1] = field.GetValue(null);
					i++;
				};
				Stream f = File.Open(filename, FileMode.Create);
				BinaryFormatter formatter = new BinaryFormatter(); //Soapformatter -> .NET 4.5 -> doesn´t run under xp!
				// SoapFormatter formatter = new SoapFormatter();
				formatter.Serialize(f, a);
				f.Close();
				return true;
			}
			catch(Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString()); //Better error messages
				return false;
			}
		}
		public static bool Load(Type static_class, string filename)
		{
			try
			{
				FieldInfo[] fields = static_class.GetFields(BindingFlags.Static | BindingFlags.Public );
				object[,] a;
				Stream f = File.Open(filename, FileMode.Open);
				BinaryFormatter formatter = new BinaryFormatter();
				a = formatter.Deserialize(f) as object[,];
				f.Close();
				if (a.GetLength(0) != fields.Length-1) return false;
				
				foreach ( FieldInfo field in fields)  
					for(int i=0;i< fields.Length-1;i++) //I ran into problems that some fields are dropped,now everyone is compared to everyone, problem fixed
						if (field.Name == (a[i, 0] as string))
							field.SetValue(null, a[i,1]);
				return true;
			}
			catch(Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString());
				return false;
			}
		}
	}
