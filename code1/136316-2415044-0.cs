public class EigenSolver
{
   public double[] _aa;
   /*
   There really is no reason to allow callers to pass a pointer here, 
   just make them pass the array.
   public EigenSolver(double* ap)
   {
      aPtr = ap;
   }
   */
   public EigenSolver(double[] aa)
   {
     _aa = aa;
   }
   public void Solve()
   {
     unsafe {
        fixed (double* ptr = _aa) {
           Interop.CallFortranCode(ptr);
        }
     }
   }
}
