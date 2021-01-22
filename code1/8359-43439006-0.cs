                try
                {
					// do some work here
                }
                catch (WebException ex)
                {
                    // catch a web excpetion
                }
				catch (ArgumentException ex)
				{
					// do some stuff
				}
                catch (Exception ex)
                {
					// you should really surface your errors but this is for example only
                    throw new Exception("An error occurred: " + ex.Message);
                }
