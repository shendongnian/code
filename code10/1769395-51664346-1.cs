        private bool SetError(ExcelRange cell, string errorComment)
		{			
			var			fill		= cell.Style.Fill;
			fill.PatternType		= OfficeOpenXml.Style.ExcelFillStyle.Solid;
			fill.BackgroundColor.SetColor(System.Drawing.Color.Red);
			cell.AddComment(errorComment, "");
			return false;
		}
        private bool ValidateHeaderColumns(ExcelWorksheet worksheet, int totlaColumns)
		{
			bool				result					= true;
			List<string>		listColumnHeaders		= GetColumnHeaders();
			for (int i = 1; i < totlaColumns; i++)
			{
				var				cell					= worksheet.Cells[1, i]; //header columns are in first row
				if (cell.Value != null)
				{
					//column header has a value
					if (!listColumnHeaders.Contains(cell.Value.ToString()))
					{
						result							&= SetError(cell, "Invalid header. Please correct.");
					}
				}
				else
				{
					//empty header
					result								&= SetError(cell, "Empty header. Remove the column.");
				}
			}
			return result;
		}
        private bool ValidateRows(ExcelWorksheet worksheet, int totalRows, int totalCols)
		{
			bool		result				= true;
			for (int i = 2; i <= totalRows; i++) //data rows start from 2`
			{
				for (int j = 1; j <= totalCols; j++)
				{
					var			cell		= worksheet.Cells[i, j];
					switch (j)
					{
						//email address
						case 1:
							{
								result		&= ValidateEmailAddress(cell, "Email address");
								break;
							}
						//first name
						case 2:
							{
								result		&= ValidateText(cell, "First name");
								break;
							}
						//last name
						case 3:
							{
								result		&= ValidateText(cell, "Last name");
								break;
							}
						//address line 1
						case 4:
							{
								result		&= ValidateText(cell, "Address line 1");
								break;
							}
						//address line 2
						case 5:
							{
								result		&= ValidateText(cell, "Address line 2");
								break;
							}
						//city
						case 6:
							{
								result		&= ValidateText(cell, "City");
								break;
							}
						//telephone number
						case 7:
							{
								result		&= ValidateText(cell, "Telephone number");
								break;
							}
						//mobile number
						case 8:
							{
								result		&= ValidateText(cell, "Mobile number");
								break;
							}
						//job title
						case 9:
							{
								result		&= ValidateJobTitle(cell, "Job title");
								break;
							}
						//salary
						case 10:
							{
								result		&= ValidateNumber(cell, "Salary");
								break;
							}
						//role
						case 11:
							{
                                result      &= ValidateRole(cell, "Role");
								break;
							}
						//branch
						case 12:
							{
								result		&= ValidateBranch(cell, "Branch");
								break;
							}
						//joined date
						case 13:
							{
								result		&= ValidateDate(cell, "Joined date");
								break;
							}
					}					
				}
			}
			return result;
		}
        private bool ValidateEmailAddress(ExcelRange cell, string columnName)
		{
			bool		result		= true;
			result					= ValidateText(cell, columnName); //validate if empty or not
			if (result)
			{
				if (!ValidateEmail(cell.Value.ToString())) //ValidateEmail => true, if email format is correct
				{
					result			= SetError(cell, "Email address format is invalid.");
				}
				else if (cell.Value.ToString().Length > 150)
				{
					result			= SetError(cell, "Email address too long. Max characters 150.");
				}
			}
			return result;
		}
        private bool ValidateText(ExcelRange cell, string columnName)
		{
			bool		result		= true;
			string		error		= string.Format("{0} is empty", columnName);
			if (cell.Value != null)
			{
				//check if cell value has a value
				if (string.IsNullOrWhiteSpace(cell.Value.ToString()))
				{
					result			= SetError(cell, error);
				}
			}
			else
			{
				result				= SetError(cell, error);
			}
			return result;
		}
        private bool ValidateNumber(ExcelRange cell, string columnName)
		{
			bool		result		= true;
			double		value		= 0.0;
			string		error		= string.Format("{0} format is incorrect.", columnName);
			result					= ValidateText(cell, columnName);
			if (result)
			{
				if (!double.TryParse(cell.Value.ToString(), out value))
				{
					result			= SetError(cell, error);
				}
			}
			return result;
		}
        private bool ValidateDate(ExcelRange cell, string columnName)
		{
			bool			result		= true;
			DateTime		date		= DateTime.MinValue;
			string			error		= string.Format("{0} format is incorrect.", columnName);
			result						= ValidateText(cell, columnName);
			if (result)
			{
				if (!DateTime.TryParse(cell.Value.ToString(), out date))
				{
					result				= SetError(cell, error);
				}
			}
			return result;
		}
        private bool ValidateJobTitle(ExcelRange cell, string columnName)
		{
			bool				result				= true;
			string				error				= "Job title does not exist.";
			List<JobTitle>		listJobTitle		= JobTitle.GetJobTitles((int)JobTitle.JobTitleStatus.Active);
			result									= ValidateText(cell, columnName);
			if (result)
			{
				if (!listJobTitle.Any(x => x.Name.ToLowerInvariant() == cell.Value.ToString().ToLowerInvariant()))
				{
					result							= SetError(cell, error);
				}
			}
			return result;
		}
