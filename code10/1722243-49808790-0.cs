    public class CreateStudentDto : ICustomValidate
    {
        public string Name { get; set; }
        public void AddValidationErrors(CustomValidationContext context)
        {
            using (var scope = context.IocResolver.CreateScope())
            {
                using (var uow = scope.Resolve<IUnitOfWorkManager>().Begin())
                {
                    var studentRepository = scope.Resolve<IRepository<Student, long>>();
                    var nameExists = studentRepository.GetAll()
                        .Where(s => s.Name == Name)
                        .Any();
                    if (nameExists)
                    {
                        var key = "A student with the same name already exists";
                        var errorMessage = context.Localize("sourceName", key);
                        var memberNames = new[] { nameof(Name) };
                        context.Results.Add(new ValidationResult(errorMessage, memberNames));
                    }
                    uow.Complete();
                }
            }
        }
    }
