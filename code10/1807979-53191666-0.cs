	private DataTable GetAttributeTable()
    {
        DataTable cltAttributeTable = new DataTable("CLT_ATTRIBUTE");
        DataColumnCollection iRefColumns = cltAttributeTable.Columns;
        //BETHiddenColumn is defined for hiding certain columns at the UI
        //And can be used for manipulating entities internally
        iRefColumns.AddRange(new[]
        {
            new BETHiddenColumn { ColumnName = CLDConstants.CLTGUID, DataType = typeof(string), ReadOnly = true },
            new DataColumn { ColumnName = CLDConstants.CLTNAME, DataType = typeof(string), ReadOnly = true },
            new BETHiddenColumn { ColumnName = CLDConstants.SHEETID, DataType = typeof(string), ReadOnly = true },
            new DataColumn { ColumnName = CLDConstants.SHEETNAME, DataType = typeof(string), ReadOnly = true },
            new DataColumn { ColumnName = "OBJECT_TYPE", DataType = typeof(string), ReadOnly = true },
            new DataColumn { ColumnName = "OBJECT_NAME", DataType = typeof(string), ReadOnly = true },
            new DataColumn { ColumnName = "ATTRIBUTE_NAME", DataType = typeof(string), ReadOnly = true },
            new DataColumn { ColumnName = "ATTRIBUTE_VALUE", DataType = typeof(string), ReadOnly = false }
        });
        return cltAttributeTable;
    }
	public override async Task<DataTable> GetDataAsync(ControlNetworkStructure controlNetwork)
    {
        DataTable cltAttributeTable = new DataTable();
        try
        {
            using (var automationService = ConsumedServiceProvider.Provider.AutomationService)
            {
                foreach (string userDefinedLogicTemplate in selectedCLT)
                {
                    var controlLogicClt =
                        automationService.AutomationClt.GetControlLogicTemplate(userDefinedLogicTemplate);
                    
					cltAttributeTable = await LoopDeLoop(controlLogicClt);
                }
            }
        }
        catch (Exception exception)
        {
            LogService.LogException(this, ServiceResources.CONTEXT_CLD_EDITOR, "CLT Attribute",
                exception);
        }
        finally
        {
            // Accepting all the modification to the table before leaving this method call
            cltAttributeTable.AcceptChanges();
        }
        return cltAttributeTable;
    }
	
	//Main loop with loops adding rows
	private async Task<DataTable> LoopDeLoop(dynamic controlLogicClt)
	{
        DataTable cltAttributeTable = GetAttributeTable();
		
		foreach (ISheet sheet in await controlLogicClt.GetSheets())
		{
			foreach (IFunctionCode functionCode in await sheet.GetFunctionCodes())
			{
				cltAttributeTable = GetNewRows(cltAttributeTable, functionCode.Attributes, functionCode.Name, "FUNCTION CODE", controlLogicClt, sheet);
			}
			foreach (IInputReference inputReference in await sheet.GetInputReferences())
			{
				cltAttributeTable = GetNewRows(cltAttributeTable, inputReference.Attributes, inputReference.Name, "IREF", controlLogicClt, sheet);
			}
			foreach (IOutputReference outputReference in await sheet.GetOutputReferences())
			{							
				cltAttributeTable = GetNewRows(cltAttributeTable, outputReference.Attributes, outputReference.Name, "OREF", controlLogicClt, sheet);						
			}
			foreach (IText text in await sheet.GetTexts())
			{
				cltAttributeTable = GetNewRows(cltAttributeTable, text.Attributes, text.Name, "TEXT", controlLogicClt, sheet);
			}
		}
	}
	
	//Adds the new created rows to the DataTable
	private DataTable GetNewRows(DataTable cltAttributeTable, List<IHarmonyAttribute> attributes, string name, string objectType, dynamic controlLogicClt, ISheet sheet)
	{
		foreach (IHarmonyAttribute attribute in attributes)
		{
			cltAttributeTable.Rows.Add(GetNewRow(sourceDataRow, attribute, name, objectType, controlLogicClt, sheet));
		}
	}
	
	//Creates and populates the new row
	private DateRow GetNewRow(IHarmonyAttribute attribute, string name, string objectType, dynamic controlLogicClt, ISheet sheet)
	{
			DataRow row = GetRow(cltAttributeTable, controlLogicClt, sheet);
			row["OBJECT_TYPE"] = objectType;
			row["OBJECT_NAME"] = name;
			row["ATTRIBUTE_NAME"] = attribute.Type;
			row["ATTRIBUTE_VALUE"] = attribute.Value;	
			return row;			
	}
