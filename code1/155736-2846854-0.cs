	class A {
		protected internal void Test() { }
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
