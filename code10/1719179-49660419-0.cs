    public string Display(double clD)
    {
        totalTime = counter * clD / 3600;
        hours = (int)(counter * clD / 3600);
        minutes = (int)((totalTime - hours) * 3600 / 60);
        seconds = (int)((totalTime - hours) * 3600 % 60);
        return "Hours: " + hours + ", Minutes: " + minutes + ", Seconds: " + seconds;
    }
    private void buttonCalculate_Click(object sender, EventArgs e)
    {
        double minSkill;
        double maxSkill;
        double coolDown;
        minSkill = float.Parse(txtMinSkill.Text) * 10;
        maxSkill = float.Parse(txtMaxSkill.Text) * 10;
        coolDown = float.Parse(txtCooldown.Text);
        SkillGainCalculator skill = new SkillGainCalculator();
        skill.IntegerMax(maxSkill);
        skill.RemainderMax(maxSkill);
        skill.RemainderMin(minSkill);
        skill.IntegerMin(minSkill);
        skill.Calculate(minSkill, maxSkill);
        resultLabel.Text = skill.Display(coolDown);
    }
