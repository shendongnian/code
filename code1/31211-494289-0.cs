		public CheckAllEnumValues() {
				// somehow construct mockmapinfo here
				TableInfoEnum[] values = Enum.GetValues(typeof(TableInfoEnum));
				foreach(TableInfoEnum v in values) {
						string result = RunTableInfoCommand(mockmapinfo.Object, v);
						Console.WriteLine(Enum.GetName(typeof(TableInfoEnum), v) + ": " + result);
				}
		}
