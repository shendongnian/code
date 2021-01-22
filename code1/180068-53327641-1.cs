			ProcessEnum( enm );
		}
		public static void ProcessEnum ( FizzBuzz enm ) {
			enm.SwitchCase(
				new KeyValuePair<FizzBuzz , Action>( FizzBuzz.Fizz , FizzMethod ) ,
				new KeyValuePair<FizzBuzz , Action>( FizzBuzz.Buzz , BuzzMethod ) ,
				new KeyValuePair<FizzBuzz , Action>( FizzBuzz.FizzBuzz , FizzBuzzMethod )
				);
		}
		private static void FizzMethod () {
			System.Console.WriteLine( "" );
		}
		private static void BuzzMethod () {
			System.Console.WriteLine( "" );
		}
		private static void FizzBuzzMethod () {
			System.Console.WriteLine( "" );
		}
	}
