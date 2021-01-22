		private static T TryGetClipboardData<T>(IDataObject clipboardData, string dataFormat)
		{
			System.Reflection.FieldInfo fieldInfo = clipboardData.GetType().GetField("innerData", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
			var outerData = fieldInfo.GetValue(clipboardData);
			if (outerData == null)
			{
				return default(T);
			}
			fieldInfo = outerData.GetType().GetField("innerData", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
			var innerData = fieldInfo.GetValue(outerData);
			if (innerData is System.Runtime.InteropServices.ComTypes.IDataObject)
			{
				// It is (probably) necessary to wrap COM IDataObject to Windows.Forms.IDataObject
				System.Windows.Forms.DataObject wrappedDataObject = new System.Windows.Forms.DataObject(innerData);
				var data = wrappedDataObject.GetData(dataFormat);
				if (data is T)
				{
					return (T)data;
				}
			}
			return default(T);
		}
