	<div class="class">
    @{
        Boolean hasAnyData = Ms.Cs.value1 != null || Ms.Cs.value2 != 0 || Ms.Cs.value4 != 0 || Ms.Cs.value5 != null;
    }
        @if( hasAnyData ) {
		<h5>MySuperTitle</h5>
		<ul>
			@if (Ms.Cs.value1 != null) {
				<li> My Li1 <span>@Ms.Cs.value1</span> </li>
			}
			@if (Ms.Cs.value2 != 0) {
				<li> My Li2 <span>@Ms.Cs.value2</span> </li>
			}
			@if (true) {
				<li> My Li3 <span>--</span></li>
			}
			@if (Ms.Cs.value4 != 0) {
				<li> My Li4 <span>@Ms.Cs.value4</span></li>
			}
			@if (Ms.Cs.value5 != null) {
				<li> My Li5 <span>@Ms.Cs.value5</span></li>
			}
		</ul>
        }
	</div>
