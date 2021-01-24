     $.ajax({
            type: "POST",
            contentType: 'application/json',
            url: "api/url",
            data: JSON.stringify(courseAttended),
            success:  (response)=> {
                console.log(response);
            },
            error: (response) =>{
                console.log(response);
            }
        });
    
    public class CourseModel
    {
        public string ActuaryId { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
    }
