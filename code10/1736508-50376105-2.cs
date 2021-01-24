    public class NoteController : Controller
    {
        private readonly NotesRepository _notes;
    
        public NoteController(NotesRepository  notes)
        {
            _notes = notes;
        }
    
        [HttpGet("{userid}")]
        public async Task<IActionResult> GetNote([FromRoute] int userid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
    
            var note = await _notes.GetAsync(userId);
    
            if (note == null)
            {
                return NotFound();
            }
    
            return Ok(note);
        }
    }
