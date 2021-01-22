     public class Protocol {
          private ISpecialHandler specialHandler;
          public Protocol() {}
          public Protocol(ISpecialHandler specialHandler) {
              this.specialHandler = specialHandler;
          }
          void Same1() {}
          void Same2() {}
          
          public void DoStuff() {
              this.Same1();
              if (this.specialHandler != null) {
                  this.specialHandler.DoStuff();
              }
              this.Same2();
          }
     }
