     public FamilyMember[] FamilyMembers { get; set; }
    @for (int i = 0; i < Model.FamilyMembers.Length; i++) { 
            <li class="family-member">
              @Html.TextBoxFor(m => Model.FamilyMembers[i].FirstName, new {style = "display:none;"})
            </li>
          }
