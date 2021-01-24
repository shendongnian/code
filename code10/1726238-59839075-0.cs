    @inject HttpClient httpClient
    @if (States != null)
    {
    
    <select id="SearchStateId" name="stateId" @onchange="DoStuff" class="form-control1">
        <option>@InitialText</option>
        @foreach (var state in States)
        {
            <option value="@state.Name">@state.Name</option>
        }
    </select>
    }
    @code {
    [Parameter] public string InitialText { get; set; } = "Select State";
    private KeyValue[] States;
    private string selectedString { get; set; }
    protected override async Task OnInitializedAsync()
    {
        States = await httpClient.GetJsonAsync<KeyValue[]>("/sample-data/State.json");
    }
    private void DoStuff(ChangeEventArgs e)
    {
        selectedString = e.Value.ToString();
        Console.WriteLine("It is definitely: " + selectedString);
    }
    public class KeyValue
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    }
