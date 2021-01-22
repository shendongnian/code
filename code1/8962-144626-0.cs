        using System.Data;
    using System.Data.SqlClient;
    using System.Text;
    
    class Foo
    {
    	public static void Main ()
    	{
    		string[] parameters = {"salt", "water", "flower"};
    		SqlConnection connection = new SqlConnection ();
    		SqlCommand command = connection.CreateCommand ();
    		StringBuilder where = new StringBuilder ();
    		for (int i = 0; i < parametes.Length; i++)
    		{
    			if (i != 0)
    				where.Append (",");
    			where.AppendFormat ("@Param{0}", i);
    			command.Parameters.Add (new SqlParameter ("Param" + i, parameters [i]));
    		}
    	}
    }
