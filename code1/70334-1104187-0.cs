    public void Render(ClassroomFormViewModel model)
    {
        RenderPartial(model) //Cannot cast single instance into an IEnumerable
    }
    public string RenderPartial(IEnumerable<ClassroomFormViewModel> model)
    {
        //Do something
    }
