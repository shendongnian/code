                List<String> Errors = new List<String>();
                int chk = 3;
                if ( msg != "hello" )
                {
                    Errors.Add( "Unmatching message" );
                }
                if ( score < 20 )
                {
                    Errors.Add( "Score not satisfied" );
                }
                if ( age > 25 )
                {
                    Errors.Add( "Age not satisfied" );
                }
                if ( Errors.Count == 0 )
                {
                    return "All para success";
                }
                else if ( Errors.Count == 3)
                {
                    return "All parameter unsatisfied";
                }
                else
                {
                    return String.Format( " & ", Errors );
                }
