	public class TestClass
	{
		public void StartWorkflow()
		{
			var workflow = new Sequence
							{
								Activities =
			               			{
			               				new WriteLine {Text = "Before calling method."},
			               				// Here I would like to call the method ReusableMethod().
			               				new InvokeMethod {MethodName="ReusableMethod", TargetType = typeof(TestClass)},
			               				new WriteLine {Text = "After calling method."}
			               			}
							};
			var wf = new WorkflowApplication(workflow);
			wf.Run();
			var are = new AutoResetEvent(false);
			wf.Completed = new Action<WorkflowApplicationCompletedEventArgs>(arg => are.Set());
			are.WaitOne(5000);
		}
		public static void ReusableMethod()
		{
			Console.WriteLine("Inside method.");
		}
	}
