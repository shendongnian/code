    if (success)
                    {
                        lblSuccessMessage.Text = _successMessage + "<br /><INPUT TYPE='button' VALUE='Continue...' onClick='parent.location='" + _downloadURL + "'/>";
                        showMessage(true);                        
                    }
                    else
                    {
                        lblSuccessMessage.Text = _failureMessage;
                        showMessage(false);
                    }
