    public ActionResult MyAction(int step)
    {
        return View (new WizardControl {
           Steps = Myrepository.getSteps();
           CurrentStep = step
         });
    }
}
