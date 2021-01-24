    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, IEvent>
    {
        private readonly UniversityDbContext _context;
        public DeleteCourseCommandHandler(UniversityDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
            if (course is null) 
                return new CourseNotFoundEvent();
            _context.Courses.Remove(course);
            var saveResult = await _context.SaveChangesAsync(cancellationToken);
            if (saveResult <= 0)
            {
                throw new DeleteFailureException(nameof(course), request.Id, "Database save was not successful.");
            }
            return new CourseDeletedEvent();
        }
    }
