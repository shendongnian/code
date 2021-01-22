                    if (cash == true && terms == true)
                    {
                        checkOutImageButton.Attributes.Add("disabled", "disabled");
                        error = true;
                    }
                    else
                    {                        
                        checkOutImageButton.Attributes.Remove("disabled");
                        error = false;
                    }
