	void XamlToObject(FileStream fs, my_xaml_schema_context ctx)
	{
		using (var xxr = new xaml_xml_reader(fs, ctx))
		using (var xow = new my_obj_writer(this))
		{
			try
			{
				xxr.transform(xow);
			}
			catch (XamlObjectWriterException xex)
			{
				// ...
			}
		}
	}
