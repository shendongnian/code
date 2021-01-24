        public static async Task<int> SendEmail(string fromEmail, string toEmail, string emailMessage, string subject) {
			try {
				// Same as your example
				if (transportWeb != null)
					await transportWeb.DeliverAsync("");
				else {
					return 0;
				}
			}
			catch (System.Exception ex) {
				//throw ex;
			}
			return 1;
		}
