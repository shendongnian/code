    runMRC:
                    try
                    {
                        container.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        ExceptionManager.Publish(ex);
                        if (MessageBox.Show("A fatal error has occurred.  Please save work and restart MRC if possible.  Would you like to try to continue?", "Fatal Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            goto runMRC;
                        container.Close();
                    }
