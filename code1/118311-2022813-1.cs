	public class Proc
	{
		public System.Diagnostics.Process RealProc;
		public List<Proc> SubProcs = null;
	}
	
	void Main()
	{
		var Processes = from p in System.Diagnostics.Process.GetProcesses() select new Proc { RealProc = p, SubProcs = null };
		while (Processes.Any(pr => pr.SubProcs == null))
		{
			foreach(Proc pr in Processes)
			{
				pr.RealProc.Id.Dump();
				pr.SubProcs = Processes.Where(prx => prx.RealProc.ParentId == pr.Id).ToList();  // doesn't work because no ParentId
			}
		}
	}
