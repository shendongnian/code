            try
            {
                File.Move(oldPath, newPath);
            }
            catch (ArgumentNullException)
            {
                //source of dest filename is null
            }
            catch(ArgumentException)
            {
                //source or dest file name/path not valid
            }
            catch(UnauthorizedAccessException)
            {
                //no permission
            }
            catch (DirectoryNotFoundException)
            {
                //dir not found
            }
            catch(PathTooLongException)
            {
                //path too long
            }
            catch(NotSupportedException)
            {
                //source or desk name is invalid format
            }
            catch (IOException)
            {
                if (File.Exists(newPath))
                    //file exists
                else if (!File.Exists(oldPath))
                    //old path does not exist
                else
                    //Unknown error
            }
