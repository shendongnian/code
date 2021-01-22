Class Job
{
            Public Run(param1,param2,etc...)
            {
                   Try
                   {
                         Log("Doing Something")
                         DoSomething()
                   
                         Log("Doing Another")
                         DoAnother()
                         
                         Log("This keeps going, etc, inside of these function we make the same Log calls where it makes sense")
                         Etc()
                   }
                   Catch(JobCancelledException)
                   {
                        status="Cancelled"
                   }
            }
              Private Log(ByVal str As String)
              {
                      MessateToUser(str)
                      if(hasCancelled)
                          throw new JobCancelledException
            }
               
             private SomeEvent_WhenUserPushesCancelButton()
             {
                       hasCancelled=True
             }
}
