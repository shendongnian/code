    interface ComObjectReleaser {
        public virtual Release (IntPtr obj) {
           Marshal.Release(obj);
        }
    }
    
    class ClassWithComObject : IDisposable {
    
        public ClassWithComObject (ComObjectReleaser releaser) {
           m_releaser = releaser;
        }
    
        // Create an int object
        ComObjectReleaser m_releaser;
        int obj = 1;
        IntPtr m_pointer = Marshal.GetIUnknownForObject(obj);
    
        public void Dispose() {
          m_releaser.Release(m_pointer);
        }
    }
    
    //Using MOQ - the best mocking framework :)))
    class ClassWithComObjectTest {
    
        public DisposeShouldReleaseComObject() {
           var releaserMock = new Mock<ComObjectReleaser>();
           var target = new ClassWithComObject(releaserMock);
           target.Dispose();
           releaserMock.Verify(r=>r.Dispose());
        }
    }
