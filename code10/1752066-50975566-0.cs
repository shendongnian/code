    var listYears = window.ExecuteScript(@"
                   
                        $=jQuery;
                        var years = [];
                        var thisYear = 0;
                        $('time').each(function(){
                            thisYear = parseInt($(this).attr('datetime').split('-')[0]);
                        // do something with thisYear...
                            years.push(thisYear);
                        });
                        // Write all years to console window.
                        return years.toString();
                        ");
            System.Diagnostics.Debug.WriteLine("*************************");
            System.Diagnostics.Debug.WriteLine("*************************");
            System.Diagnostics.Debug.WriteLine("*************************");
            System.Diagnostics.Debug.WriteLine("listYears: " + listYears);
            System.Diagnostics.Debug.WriteLine("*************************");
            System.Diagnostics.Debug.WriteLine("*************************");
            System.Diagnostics.Debug.WriteLine("*************************");
