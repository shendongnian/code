    <select style="height:auto" class="form-control " id="Permissions" name="Permissions" value="@permission">
                     <!--   <option value="null"
                                @if (permission.Text == null) { <text> selected</text>    }>
                        Permissions
                        </option>
     -->
                        @for (int i = 0; i < ViewBag.Permissions.Count; i++)
    
                        {
                          <option value="@ViewBag.Permissions[i].Text "
                                  @if (permission.Text == ViewBag.Permissions[i].Text ) { <text> selected</text>}>
                            @ViewBag.Permissions[i].Text 
                          </option>
                        }
                      </select> 
