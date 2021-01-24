    //Matches PUT api/Teacher/UpdateTeacherForInterview/1
    [HttpPut("UpdateTeacherForInterview/{id:int}")]
    public IActionResult PutTeacherForInterview(int id, [FromBody]UpdateInterviewModel model) {
        return Ok();
    }
