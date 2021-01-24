    @using (Html.BeginForm("GetVistaParcial", "Home"))
    {
      @Html.RadioButtonFor(model => model.TipoVP, new 
         string("VP_A".ToCharArray()), new { @checked = "checked" })
             <span class="custom-control-label">Partial View A</span>
      @Html.RadioButtonFor(model => model.TipoVP, new 
         String("VP_B".ToCharArray()))
           <span class="custom-control-label">Partial View B</span> 
      <input type="submit" value="submit" />
    }
