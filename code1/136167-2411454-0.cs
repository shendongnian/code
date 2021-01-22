    [Synchronization]
    public class Deadlock : ContextBoundObject {
    	public DeadLock Other;
    	public void Demo() { Thread.Sleep (1000); Other.Hello(); }
    	void Hello() { Console.WriteLine ("hello"); }
    }
    public class Test {
    	static void Main() {
    	Deadlock dead1 = new Deadlock();
    	Deadlock dead2 = new Deadlock();
    	dead1.Other = dead2;
    	dead2.Other = dead1;
    	new Thread (dead1.Demo).Start();
    	dead2.Demo();
    }
