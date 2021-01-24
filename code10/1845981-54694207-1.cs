    string SelectNameToDisplay(IEnumerable<Person> persons)
    {
        TODO: implement
    }
    private void btnPopularCourse_Click(object sender, EventArgs e)
    {
         IEnumerable<Person> persons = ReadPersons();
         string nameToDisplay = SelectNameToDisplay(persons);
         DisplayName(nameToDisplay);
    }
