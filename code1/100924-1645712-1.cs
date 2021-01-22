    public enum Status { OK, Error, Warning, Fatal }
    public interface IProcessStage {
        String Error { get; }
        Status Status { get; }
        bool Run();
    }
    public class SuccessfulStage : IProcessStage {
        public String Error { get { return null; } }
        public Status Status { get { return Status.OK; } }
        public bool Run() { return performStep1(); }
    }
    public class WarningStage : IProcessStage {
        public String Error { get { return "Warning"; } }
        public Status Status { get { return Status.Warning; } }
        public bool Run() { return performStep2(); }
    }
    public class ErrorStage : IProcessStage {
        public String Error { get { return "Error"; } }
        public Status Status { get { return Status.Error; } }
        public bool Run() { return performStep3(); }
    }
    class Program {
        static Status RunAll(List<IProcessStage> stages) {
            Status stat = Status.OK;
            foreach (IProcessStage stage in stages) {
                if (stage.Run() == false) {
                    stat = stage.Status;
                    if (stat.Equals(Status.Error)) {
                        break;
                    }
                }
            }
            // perform final processing
            return stat;
        }
        static void Main(string[] args) {
            List<IProcessStage> stages = new List<IProcessStage> {
                new SuccessfulStage(),
                new WarningStage(),
                new ErrorStage()
            };
            Status stat = Status.OK;
            try {
                stat = RunAll(stages);
            } catch (Exception e) {
                // log exception
                stat = Status.Fatal;
            } finally {
                // cleanup
            }
        }
    }
