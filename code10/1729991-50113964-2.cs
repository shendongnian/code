    public class StudentModule : NinjectModule
        {
            public override void Load()
            {
                Bind<IStudentService>().To<StudentService>();
            }
        }
    }
