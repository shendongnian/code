    for (int x = 0; x < (arr.Length - 1); x++)
            {
                byte[] fpbyte = GetStringToBytes(arr[x]);
                using (Stream stream = new MemoryStream(fpbyte))
                {
                    Data.Templates[x] = new DPFP.Template(stream);
                    // Get template from storage.
                    if (Data.Templates[x] != null)
                    {
                        // Compare feature set with particular template.
                        ver.Verify(FeatureSet, Data.Templates[x], ref res);
                        Data.IsFeatureSetMatched = res.Verified;
                        Data.FalseAcceptRate = res.FARAchieved;
                        if (res.Verified)
                        {
                            status.Text = "Verified";
                            break; // success
                        }
                        
                    }
                    
                }
            }
            if (!res.Verified)
            {
                Status = DPFP.Gui.EventHandlerStatus.Failure;
                status.Text = "Unverified";
            }
            Data.Update();
