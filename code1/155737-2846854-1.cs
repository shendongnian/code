	class A {
		protected internal void Test() { } //only available to subclasses of A in A's assembly
		public void Test2(){}//available to everyone
		protected void Test3(){} //available to subclasses of A in any assembly
		internal void Test4(){} //available to any class in A's assembly 
	}
	class B : A {
		void TestA() {
			Test(); //OK
		}
	}
	//Different assembly
	class C : B {
		void TestA() {
			Test(); //Boom
		}
	}
