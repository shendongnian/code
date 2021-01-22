    public class MyVeryBaseClass {
    	protected void RealDispose(bool isDisposing) {
    		IDisposable tryme = this as IDisposable;
    		if (tryme != null) { // we implement IDisposable
    			this.Dispose();
    			base.RealDispose(isDisposing);
    		}
    	}
    }
    public class FirstChild : MyVeryBaseClasee {
    	//non-disposable
    }
    public class SecondChild : FirstChild, IDisposable {
    	~SecondChild() {
    		Dispose(false);
    	}
    	public void Dispose() {
    		Dispose(true);
    		GC.SuppressFinalize(this);
    		base.RealDispose(true);
    	}
    	protected virtual void Dispose(bool bDisposing) {
    		if (!m_bDisposed) {
    			if (bDisposing) {
    			}// Dispose managed resources
    		} // Dispose unmanaged resources
    	}
    }
