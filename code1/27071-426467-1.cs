    private void RobustMoveFile( System.IO.DirectoryInfo destinationDirectory, System.IO.FileInfo sourceFile, Boolean retryMove )
            		{
            			try
            			{
            				string DestinationFile = Path.Combine( destinationDirectory.FullName, sourceFile.Name );
            				if ( File.Exists( DestinationFile ) )
            					sourceFile.Replace( DestinationFile, DestinationFile + "Back", true );
            				else
            				{
            					sourceFile.CopyTo( DestinationFile, true );
            					sourceFile.Delete();
            				}
            			}
            			catch ( System.IO.IOException IOEx )
            			{
            				int HResult = System.Runtime.InteropServices.Marshal.GetHRForException( IOEx );        
            				const int SharingViolation = 32;
            				if ( ( HResult & 0xFFFF ) == SharingViolation && retryMove )
            					RobustMoveFile( destinationDirectory, sourceFile, false );
            				throw;
            			}
            		}
